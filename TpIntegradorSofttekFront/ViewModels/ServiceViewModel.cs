using Data.DTOs;

namespace TpIntegradorSofttekFront.ViewModels
{
    public class ServiceViewModel
    {
		public int Id { get; set; }
		public string Description { get; set; }
		public bool State { get; set; }
		public decimal HourValue { get; set; }

		public static implicit operator ServiceViewModel(ServiceDto dto)
        {
            var viewModel = new ServiceViewModel();
			viewModel.Id = dto.Id;
			viewModel.Description = dto.Description;
            viewModel.State = dto.State;
			viewModel.HourValue = dto.HourValue;
            return viewModel;
        }
    }
}
