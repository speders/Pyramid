
namespace Pyramid
{
    class PyramidNode
    {
        public PyramidNode(int value)
        {
            Value = value;
        }

        public int Value { get; set; }
        public string Path { get; set; }
        public int Total { get; set; }
        public PyramidNode[] Children { get; set; }
    }
}