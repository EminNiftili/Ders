using DataAccess.EfImplementations.Contexts;
using DataAccess.EfImplementations.Repositories;
using DataAccess.Repositories;
using DataAccess.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EfImplementations
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public EfUnitOfWork(DersDb2Context context)
        {
            _context = context;
        }

        private IPersonRepository? _personRepository;
        public IPersonRepository PersonRepository
        {
            get
            {
                if(_personRepository == null)
                {
                    _personRepository = new EfPersonRepository(_context);
                }
                return _personRepository;
            }
        }

        private ILessonRepository? _lessonRepository;
        public ILessonRepository LessonRepository
        {
            get
            {
                if (_lessonRepository == null)
                {
                    _lessonRepository = new EfLessonRepository(_context);
                }
                return _lessonRepository;
            }
        }

        private IStudentRepository? _studentRepository;
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new EfStudentRepository(_context);
                }
                return _studentRepository;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
