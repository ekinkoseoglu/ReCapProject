using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backbone.Utilities.Results;
using Business.Abstract;
using Castle.Core.Internal;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditCardManager: ICreditCardService
    {
        public ICreditCardDal _creditCardDal;
        public IUserService _userService;

        public CreditCardManager(ICreditCardDal creditCardDal, IUserService userService)
        {
            _creditCardDal = creditCardDal;
            _userService = userService;
        }


        public IDataResult<List<CreditCard>> GetAllCards()
        {
            var result = _creditCardDal.GetAll();

            if (!result.IsNullOrEmpty())
            {
                return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), "Credit Cards Are Listed");
            }

            else
            {
                return new ErrorDataResult<List<CreditCard>>( "There is no Card Information In Our DB");
            }

            
        }

        public IDataResult<List<CreditCard>> GetCardsByUserId(int id)
        {
            var result = _creditCardDal.GetAll(c => c.UserId == id);
            if (result != null)
            {
                return new SuccessDataResult<List<CreditCard>>(result,"Users Credit Cards Are Listed");
            }

            return new ErrorDataResult<List<CreditCard>>("There are not Credit Card of Selected User");
        }

        public IResult AddCardForUser(CreditCard creditCard)
        {
            var UserToAddCard = _userService.Get(creditCard.UserId);
            if (UserToAddCard == null)
            {
                return new ErrorResult("No User Found By Given ID");
            }

            _creditCardDal.Add(creditCard);
            return new SuccessResult("Credit Card Has Added on Spesific User");

        }


        public IResult Delete(int id)
        {
            var cardToDelete = this.GetCardsByUserId(id); // User ID

            if (cardToDelete != null)
            {
                foreach (var card in cardToDelete.Data)
                {
                    _creditCardDal.Delete(card);
                    
                }

                return new SuccessResult("Deleted All Card of User");
            }
            else
            {
                return new ErrorResult("There is no User Found By Given Id");
            }

        }
    }
}
