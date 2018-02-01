namespace MyPhotoshop
{
    public class GrayscaleFilter : IFilter
    {
        public ParameterInfo[] GetParameters()
        {
            return new ParameterInfo[0];
        }

        public override string ToString()
        {
            return "Оттенки серого.";
        }


        public Photo Process(Photo original, double[] parameters)
        {
            var result = new Photo(original.width, original.height);
            for (var x = 0; x < result.width; x++)
            {
                for (var y = 0; y < result.height; y++)
                {
                    var lightness = (original[x, y].R + original[x, y].G + original[x, y].B) / 3;
                    result[x, y] = new Pixel(lightness, lightness, lightness);
                }
            }

            return result;
        }
    }
}