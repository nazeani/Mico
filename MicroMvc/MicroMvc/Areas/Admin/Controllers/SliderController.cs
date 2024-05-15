using Business.Services.Abstracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
       private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public IActionResult Index()
        {
            var sliders = _sliderService.GetAllSlider();

            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            _sliderService.AddSlider(slider);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        { 
            var existSlider= _sliderService.GetSlider(x=>x.Id==id);
            return View(existSlider);
        }
        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            _sliderService.DeleteSlider(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var Slider = _sliderService.GetSlider(x => x.Id == id);
            return View(Slider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            _sliderService.UpdateSlider(slider.Id, slider);
            return RedirectToAction("Index");
        }




    }
}
