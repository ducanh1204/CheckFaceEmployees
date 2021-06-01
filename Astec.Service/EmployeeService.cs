using Astec.Data.Infrastructure;
using Astec.Data.Repositories;
using Astec.Model.Models;
using System.Collections.Generic;

namespace Astec.Service
{
    public interface IEmployeeService
    {
        IEnumerable<EMPLOYEE> GetAll();

        EMPLOYEE GetById(int id);

        EMPLOYEE Add(EMPLOYEE employee);

        void Save();
    }

    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public EMPLOYEE Add(EMPLOYEE employee)
        {
            return _employeeRepository.Add(employee);
        }

        public IEnumerable<EMPLOYEE> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public EMPLOYEE GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}