namespace MethodSimplex
{
    public interface ISimplex
    {
        void Calculate();
        double Answer { get; }
        void GetDataFromFile(string path);
    }
}