using Data.Entities;
using Laboratorium_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Laboratorium_3.Services.Interfaces
{
    public interface IContactService
    {
        int Add(Contact book);
        void Delete(int id);
        void Update(Contact book);
        List<Contact> FindAll();
        Contact? FindById(int id);
        List<OrganizationEntity> FindAllOrganizationsForVieModel();

        public PagingList<Contact> FindPage(int page, int size);
        
        

    }
}
