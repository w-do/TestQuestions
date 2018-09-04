using Triangle.Enumerations;

namespace Triangle.Interfaces
{
    interface ITriangleService
    {
        TriangleType GetTriangleType(int sideOne, int sideTwo, int sideThree);
    }
}
