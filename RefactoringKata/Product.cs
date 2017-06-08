using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public class Product
    {
        public static int SIZE_NOT_APPLICABLE = -1;

        public string Code { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = color;
            Size = size;
            Price = price;
            Currency = currency;
        }

        public string getColorFor()
        {
            switch (Color)
            {
                case 1:
                    return "blue";
                case 2:
                    return "red";
                case 3:
                    return "yellow";
                default:
                    return "no color";
            }
        }

        public string getSizeFor()
        {
            switch (Size)
            {
                case 1:
                    return "XS";
                case 2:
                    return "S";
                case 3:
                    return "M";
                case 4:
                    return "L";
                case 5:
                    return "XL";
                case 6:
                    return "XXL";
                default:
                    return "Invalid Size";
            }
        }

        public bool ShouldSerializeSize()
        {
            return Size != SIZE_NOT_APPLICABLE;
        }

        public bool IS_NOT_SIZE_APPLICABLE()
        {
            return Size == Product.SIZE_NOT_APPLICABLE;
        }

        public string ProductFormat()
        {
            var products = CreateProdProperties().Select(prodProperty =>
                    {
                        return string.Format("\"{0}\": {1}", prodProperty.Key, (prodProperty.Value is string) ? "\"" + prodProperty.Value + "\"" : prodProperty.Value);
                    }).ToArray();

            return "{" + string.Join(", ", products) + "}";
        }

        private Dictionary<string, object> CreateProdProperties()
        {
            var prodProperties = new Dictionary<string, object>()
            {
                {"code", Code},
                {"color", getColorFor()},
                {"size", getSizeFor()},
                {"price", Price},
                {"currency", Currency}
            };

            if (IS_NOT_SIZE_APPLICABLE())
                prodProperties.Remove("size");
            return prodProperties;
        }
    }
}
