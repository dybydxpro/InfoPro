using Industrial_Engineering.Modals;

namespace Industrial_Engineering.Services.Context
{
    public interface IStyleService
    {
        List<Style> GetStyles();
        Style GetStyleById(int id);
        Style CreateStyle(Style style);
        Style UpdateStyle(Style style);
        Style DeleteStyle(int id);
    }
}
