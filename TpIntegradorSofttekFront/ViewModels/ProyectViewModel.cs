using Data.DTOs;

namespace TpIntegradorSofttekFront.ViewModels
{
    public class ProyectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int State { get; set; }

        public static implicit operator ProyectViewModel(ProyectDto dto)
        {
            var viewModel = new ProyectViewModel();
            viewModel.Id = dto.Id;
            viewModel.Name = dto.Name;
            viewModel.State = dto.State;
            viewModel.Address = dto.Address;
            return viewModel;
        }
    }
}
