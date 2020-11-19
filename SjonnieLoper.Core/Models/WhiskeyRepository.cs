using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SjonnieLoper.Core.Models
{
    public static class WhiskeyRepository
    {
        public static IEnumerable<SelectListItem>
            GetWhiskeysSelectList(this IEnumerable<Whiskey> whiskey)
        {
            List<SelectListItem> whiskeys = 
                whiskey.OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();
            /*var emptyField = new SelectListItem()
            {
                Value = "0",
                Text = "--- select a product ---"
            };
            whiskeys.Insert(0, emptyField);
            whiskeys[0].Value = "0";*/
            return new SelectList(whiskeys, "Value", "Text");
        }
        
        
        public static IEnumerable<SelectListItem>
            GetWhiskeyTypesSelectList(this IEnumerable<WhiskeyType> whiskeyType)
        {
            List<SelectListItem> types = 
                whiskeyType.Select(n =>
                        new SelectListItem
                        {
                            Value = n.Id.ToString(),
                            Text = n.Name
                        }).ToList();
            var emptyField = new SelectListItem()
            {
                Value = "0",
                Text = "--- Choose a type ---"
            };
            types.Insert(0, emptyField);
            return new SelectList(types, "Value", "Text");
        }
        
    }
}