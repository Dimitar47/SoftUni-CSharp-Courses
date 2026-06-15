using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller() 
        {
        booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded,
                booth.BoothId,
                booth.Capacity);

        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if(delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            IRepository<IDelicacy> delicacies = booth.DelicacyMenu;
            IDelicacy delicacy = delicacies.Models.FirstOrDefault(x => x.Name == delicacyName);
            if(delicacy != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }
            if(delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if(delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            delicacies.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName
                , delicacyName);
        }
        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if(cocktailTypeName!="MulledWine" && cocktailTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }
            if(size != "Large" && size !="Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }
            IBooth booth = booths.Models.FirstOrDefault(x => x.BoothId == boothId);
            IRepository<ICocktail> cocktails = booth.CocktailMenu;
            ICocktail currentCocktail = cocktails.Models
                .FirstOrDefault(x => x.Name == cocktailName && x.Size == size);
            if (currentCocktail != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, 
                    size, cocktailName);
            }
            if (cocktailTypeName == "MulledWine")
            {
                currentCocktail = new MulledWine(cocktailName, size);
            }
            else if(cocktailTypeName == "Hibernation")
            {
                currentCocktail = new Hibernation(cocktailName, size);
            }
            cocktails.AddModel(currentCocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size,
                cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
           List<IBooth> boothsList = booths.Models.Where(x=>!x.IsReserved && x.Capacity
           >=countOfPeople).OrderBy(x=>x.Capacity).ThenByDescending(x=>x.BoothId).ToList();
            IBooth firstBooth = boothsList.FirstOrDefault();
            if(firstBooth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }
            firstBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, 
                firstBooth.BoothId,
                countOfPeople);



        }
        public string TryOrder(int boothId, string order)
        {
            string[] orderSequence = order.Split("/").ToArray();
            string itemTypeName = orderSequence[0];
            string itemName = orderSequence[1];
            int countOfOrderedPieces = int.Parse(orderSequence[2]);
            string size = "";
            if (orderSequence.Length == 4)
            {
                size = orderSequence[3];
            }
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);
            IRepository<ICocktail> cocktails = booth.CocktailMenu;
            IRepository<IDelicacy> delicacies = booth.DelicacyMenu;
            if (itemTypeName != "MulledWine" && itemTypeName != "Hibernation"
                && itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
            if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation") 
            { 
                if (cocktails.Models.FirstOrDefault(x => x.Name == itemName) == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName,
                    itemTypeName,
                     itemName);
                }
               
                ICocktail cocktail = cocktails.Models.FirstOrDefault
                    (x=>
                    x.GetType().Name == itemTypeName &&
                    x.Name == itemName && 
                    x.Size == size);
               if(cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName,
                        size,
                        itemName);
                }
                double amount = cocktail.Price * countOfOrderedPieces;
                booth.UpdateCurrentBill(amount);
                return string.Format(OutputMessages.SuccessfullyOrdered,
                    booth.BoothId,
                    countOfOrderedPieces,
                    itemName);
            }
            else  
            {
                if (delicacies.Models.FirstOrDefault(x => x.Name == itemName) == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName,
                        itemTypeName,
                         itemName);
                }
                IDelicacy delicacy = delicacies.Models.FirstOrDefault
                   (x =>
                   x.GetType().Name == itemTypeName &&
                   x.Name == itemName);
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName,
                        itemTypeName,
                        itemName);
                }
                double amount = delicacy.Price * countOfOrderedPieces;
                booth.UpdateCurrentBill(amount);
                return string.Format(OutputMessages.SuccessfullyOrdered,
                    booth.BoothId,
                    countOfOrderedPieces,
                    itemName);
            }

        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.Turnover:f2} lv");
            sb.AppendLine($"Booth {booth.BoothId} is now available!");
            return sb.ToString().TrimEnd();
        }
        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.First(x => x.BoothId == boothId);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(booth.ToString());
            return sb.ToString().TrimEnd();
        }

      

       

      
    }
}
