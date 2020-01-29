using System;
using System.Collections.Generic;
using System.Text;

namespace CodesTable.Data
{
    public class CodeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static ICollection<CodeCategory> ToPickList()
        {
            ICollection<CodeCategory> list = new List<CodeCategory>();

            foreach (Constants.CategoryType c in (Constants.CategoryType[])Enum.GetValues(typeof(Constants.CategoryType)))
            {
                list.Add(new CodeCategory()
                {
                    Id = c.Value(),
                    Name = c.Description()
                });

            }
            return list;
        }
    }
}
