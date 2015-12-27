namespace FMScoutFramework.Core.Entities.InGame.Interfaces
{
    public interface INation
    {
        int ID { get; }
        string Name { get; }
        string NationalityName { get; }
        RivalNation[] RivalNations { get; }
        string ShortName { get; }
        Team[] Teams { get; }
        string ThreeLetterName { get; }
    }
}