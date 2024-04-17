namespace QuickPicSurvey.Helpers
{
    public static class LinqExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> input)
        {
            List<T> output = new();
            Random rand = new();

            foreach (T entry in input)
            {
                int position = rand.Next(output.Count);
                output.Add((position == output.Count) ? entry : output[position]);
                output[position] = entry;
            }

            return output;
        }
    }
}
