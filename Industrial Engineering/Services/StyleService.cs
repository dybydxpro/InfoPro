using Industrial_Engineering.Data;
using Industrial_Engineering.Modals;
using Industrial_Engineering.Services.Context;

namespace Industrial_Engineering.Services
{
    public class StyleService : IStyleService
    {
        protected readonly IndustrialEngineeringDbContext _context;
        protected readonly IIndustrialEngineeringUnitOfWork _unitOfWork;

        public StyleService(IndustrialEngineeringDbContext context, IIndustrialEngineeringUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public List<Style> GetStyles()
        {
            List<Style> styles = _unitOfWork.StyleRepository.GetAll().ToList();
            return styles;
        }

        public Style GetStyleById(int id)
        {
            Style style = _unitOfWork.StyleRepository.GetAll().Where(d => d.Id == id).FirstOrDefault();
            return style;
        }

        public Style CreateStyle(Style style)
        {
            _unitOfWork.StyleRepository.Insert(style);
            _unitOfWork.SaveChanges();
            _unitOfWork.StyleRepository.Reload(style);
            return style;
        }

        public Style UpdateStyle(Style style)
        {
            _unitOfWork.StyleRepository.Update(style);
            _unitOfWork.SaveChanges();
            _unitOfWork.StyleRepository.Reload(style);
            return style;
        }

        public Style DeleteStyle(int id)
        {
            Style style = GetStyleById(id);
            if (style == null)
                throw new Exception("Designation not found!");

            _unitOfWork.StyleRepository.Delete(style);
            _unitOfWork.SaveChanges();
            return style;
        }
    }
}
