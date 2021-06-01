using Astec.Model.Models;
using Astec.Service;
using AutoMapper;
using CheckFaceEmployees.Api.Infrastructure.Core;
using CheckFaceEmployees.Api.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckFaceEmployees.Api.Api
{
    [RoutePrefix("api/employees")]
    public class EmployeeController : ApiControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IErrorService errorService, IEmployeeService employeeService) : base(errorService)
        {
            _employeeService = employeeService;
        }


        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request = null)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _employeeService.GetAll();
                var responseData = Mapper.Map<IEnumerable<EMPLOYEE>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getemployeebyfinger")]
        [HttpPost]
        public HttpResponseMessage GetAllURLValue([FromBody] string finger, HttpRequestMessage request = null)
        {
            return CreateHttpResponse(request, () =>
            {
                int result = 0;
                var employee_getall = _employeeService.GetAll();
                EMPLOYEE employee = new EMPLOYEE();
                IEnumerable<EMPLOYEE> employeeList = Mapper.Map<IEnumerable<EMPLOYEE>>(employee_getall);
                foreach (var item in employeeList)
                {
                    result = 0;
                    byte[] fingerByte = Convert.FromBase64String(finger);
                    byte[] fingerDb = item.Finger;

                    //IAuthenticator authenticator = new Authenticator();
                    //result = authenticator.Authenticate(fingerByte, fingerDb);
                    //if ()
                    //{
                    //    break;
                    //}
                }
                var response = request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create([FromBody] EmployeeViewModel employeeViewModel, HttpRequestMessage request = null)
        {
            return CreateHttpResponse(request, () =>
            {
                EMPLOYEE newem = new EMPLOYEE();
                try
                {
                    newem.Photo = Convert.FromBase64String(employeeViewModel.Photo);
                }
                catch (Exception)
                {
                    newem.Photo = null;
                }
                try
                {
                    newem.Finger = Convert.FromBase64String(employeeViewModel.Finger);
                }
                catch (Exception)
                {
                    newem.Finger = null;
                }
                newem.NameEn = employeeViewModel.NameEn;
                newem.NameVn = employeeViewModel.NameVn;
                newem.Gender = employeeViewModel.Gender;
                newem.Bod = employeeViewModel.Bod;
                newem.Country = employeeViewModel.Country;
                newem.Address = employeeViewModel.Address;
                newem.PaperType = employeeViewModel.PaperType;
                newem.PassportNumber = employeeViewModel.PassportNumber;
                newem.IssueDate = employeeViewModel.IssueDate;
                newem.ExpireDate = employeeViewModel.ExpireDate;
                newem.Cccd = employeeViewModel.Cccd;
                newem.Cmtc = employeeViewModel.Cmtc;

                var newEmployee = _employeeService.Add(newem);
                _employeeService.Save();
                var responseData = Mapper.Map<EMPLOYEE>(newEmployee);
                if (responseData != null)
                {
                    var response = request.CreateResponse(HttpStatusCode.Created, "Thêm thành công");
                    return response;
                }
                else
                {
                    var response = request.CreateResponse(HttpStatusCode.Created, "Thêm thất bại");
                    return response;
                }

            });
        }

        [Route("getemployeebyid")]
        [HttpPost]
        public HttpResponseMessage GetEmployeeById(int id, HttpRequestMessage request = null)
        {
            return CreateHttpResponse(request, () =>
            {
                EMPLOYEE employee = _employeeService.GetById(id);

                var response = request.CreateResponse(HttpStatusCode.OK, employee);
                return response;
            });
        }
    }
}