using SqlApplication.Entities;
using SqlApplication.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SqlApplication.Services;

public class CompanyService
{
    private readonly CompanyRepository _companyRepository;

    public CompanyService(CompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public CompanyEntity CreateNewCompany(string companyName)
    {
        try
        {
            var result = _companyRepository.GetOne(x => x.CompanyName == companyName);
            result ??= _companyRepository.Create(new CompanyEntity { CompanyName = companyName });

            return new CompanyEntity { Id = result.Id, CompanyName = result.CompanyName };
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null!;
    }

    public CompanyEntity GetCompanyByName(string companyName)
    {
        var companyEntity = _companyRepository.GetOne(x =>x.CompanyName == companyName);
        return companyEntity;
    }

    public CompanyEntity GetCompanyById(int id)
    {
        var companyEntity = _companyRepository.GetOne(x => x.Id == id);
        return companyEntity;

    }

    public IEnumerable<CompanyEntity> GetAll()
    {
        var companies = _companyRepository.GetAll();
        return companies;
    }

    public CompanyEntity UpdateCompany(CompanyEntity companyEntity)
    {

        try
        {
            var entity = _companyRepository.GetOne(x => x.Id == companyEntity.Id);
            if (entity != null)
            {
                entity.CompanyName = companyEntity.CompanyName;

                var result = _companyRepository.Update(entity);
                if (result != null)
                    return new CompanyEntity { Id = entity.Id, CompanyName = entity.CompanyName };
            }
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return null!;
        //var updateCompany = _companyRepository.Update(x => x.Id == companyEntity.Id, companyEntity);
        //return updateCompany;
    }

    public bool DeleteCompany(Expression<Func<CompanyEntity, bool>> predicate)
    {
        try
        {
            var result = _companyRepository.Delete(predicate);
            return result;
        }
        catch (Exception ex) { Debug.Write(ex.Message); }
        return false;
        //_companyRepository.Delete(x => x.Id == id);
    }
}
