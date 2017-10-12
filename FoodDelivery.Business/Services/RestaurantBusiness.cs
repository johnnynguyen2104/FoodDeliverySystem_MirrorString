using FoodDelivery.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDelivery.Business.Dtos;
using FoodDelivery.DAL.Interfaces;
using FoodDelivery.DAL.UnitOfWork;
using System.Data.Entity;
using AutoMapper;
using FoodDelivery.DAL.DomainModels;
using FoodDelivery.Extensions;

namespace FoodDelivery.Business.Services
{
    public class RestaurantBusiness : IRestaurantBusiness
    {
        public IUnitOfWork _unitOfWork;
        public IMapper _mapper;

        public RestaurantBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public RestaurantBusiness(IMapper mapper)
        {
            _unitOfWork = new UnitOfWork();
            _mapper = mapper;
        }

        public IList<RestaurantDto> GetRestaurantsByNameOrCategory(string input)
        {
            if (!input.HasValue() || input.Length < 3)
            {
                return new List<RestaurantDto>();
            }

            var result = _unitOfWork.RestaurantsRepository.Read(a => a.IsActived
                                                                     &&
                                                                     (a.RestaurantName.Contains(input) ||
                                                                      a.Categories.Any(x => x.CategoryName.Contains(input))))
                .Include(a => a.Categories)
                .Select(a => new RestaurantDto()
                {
                    RestaurantName = a.RestaurantName,
                    Id = a.Id
                }).ToList();

            return result;
        }

        public MenuDto GetMenuByRestaurant(int restaurantId)
        {
            if (restaurantId <= 0)
            {
                return null;
            }

            var result = _unitOfWork.MenuRepository.Read(a => a.RestaurantId == restaurantId && a.Restaurant.IsActived)
                                                    .Include(a => a.Restaurant)
                                                    .Select(a => new MenuDto()
                                                    {
                                                        Name = a.Name,
                                                        RestaurantId = a.RestaurantId,
                                                        Details = a.Details.Select(b => new MenuDetailsDto()
                                                        {
                                                            Name = b.Name,
                                                            MenuId = b.MenuId,
                                                            Id = b.Id,
                                                            Price = b.Price,
                                                            ValueBy = b.ValueBy
                                                        }).ToList()
                                                    }).FirstOrDefault();

            return result;
        }

        public bool CreateOrUpdateMenu(int restaurantId, MenuDetailsDto detail)
        {
            if (restaurantId <= 0 || !_unitOfWork.RestaurantsRepository.Read(a => a.IsActived && a.Id == restaurantId).Any())
            {
                throw new ArgumentException("Invalid or Inactived restaurant", "restaurantId");
            }

            if (detail.MenuId == 0)
            {
                _unitOfWork.MenuRepository.Create(new Menu()
                {
                    RestaurantId = restaurantId,
                    Details = new List<MenuDetails>()
                    {
                        _mapper.Map<MenuDetails>(detail)
                    }
                });
            }
            else
            {
                var menudetail = _mapper.Map<MenuDetails>(detail);
                _unitOfWork.MenuDetailsRepository.Create(menudetail);
            }

            return _unitOfWork.CommitChanges() > 0;
        }
    }
}
