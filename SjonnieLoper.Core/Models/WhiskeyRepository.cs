using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SjonnieLoper.Core.Models
{
    public static class WhiskeyRepository
    {
        public static IEnumerable<SelectListItem>
            GetWhiskeyNames(this IEnumerable<Whiskey> whiskey)
        {
            List<SelectListItem> whiskeys = 
                whiskey.OrderBy(n => n.Name)
                .Select(n =>
                    new SelectListItem
                    {
                        Value = n.Id.ToString(),
                        Text = n.Name
                    }).ToList();
            var emptyField = new SelectListItem()
            {
                Value = null,
                Text = "--- select a product ---"
            };
            whiskeys.Insert(0, emptyField);
            return new SelectList(whiskeys, "Value", "Text");
        }
        
        
        public static IEnumerable<SelectListItem>
            GetWhiskeyTypes(this IEnumerable<WhiskeyType> whiskeyType)
        {
            List<SelectListItem> types = 
                whiskeyType.OrderBy(n => n.Name)
                    .Select(n =>
                        new SelectListItem
                        {
                            Value = n.WhiskeyTypeId.ToString(),
                            Text = n.Name
                        }).ToList();
            var emptyField = new SelectListItem()
            {
                Value = null,
                Text = "--- Choose a type ---"
            };
            types.Insert(0, emptyField);
            return new SelectList(types, "Value", "Text");
        }
        
    }
}