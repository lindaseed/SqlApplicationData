using SqlApplication.Entities;
using SqlApplication.Repositories;

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
        var companyEntity = _companyRepository.GetOne(x => x.CompanyName == companyName);
        companyEntity ??= _companyRepository.Create(new CompanyEntity { CompanyName = companyName});

        return companyEntity;
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
        var updateCompany = _companyRepository.Update(x => x.Id == companyEntity.Id, companyEntity);
        return updateCompany;
    }

    public void DeleteCompany(int id)
    {
        _companyRepository.Delete(x => x.Id == id);
    }
}
