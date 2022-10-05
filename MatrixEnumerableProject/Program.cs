namespace MatrixEnumerableProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 4);

            matrix.RandomInit();

            Console.WriteLine(matrix);

            foreach (var item in matrix)
                Console.Write($"{item} ");
        }
    }
}