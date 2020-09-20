using Entities.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IGeneralRepository
    {
        bool isSetConnectionString();
        void SetConnectionString(string connectionString);
        List<string> GetDeget();
        List<DitaDto> GetDitet();
        List<KlasaDto> GetKlasa();
        List<string> GetParaleli(string dega, int viti);
        List<string> GetPedagog();
        List<OrariDateKlaseDto> GetOrariDateKlaseDtos(int klasa, int dita);
        List<int> GetVitetPerDege(string dega);
        List<OrariStudentDto> GetOrariStudent(string dega, int viti, string paraleli);
        List<OrarPedagogDto> GetOrarPedagog(string emri);
    }
}
