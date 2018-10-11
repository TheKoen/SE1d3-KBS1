using KBS1.Obstacles;

namespace KBS1.Misc
{
    public interface IControllerCreator
    {
        Controller.Controller Create(Obstacle obstacle);
    }
}