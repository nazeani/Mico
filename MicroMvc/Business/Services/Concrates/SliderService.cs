using Business.Services.Abstracts;
using Core.Models;
using Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Business.Extensions;

namespace Business.Services.Concrates
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository _sliderRepository;
        private readonly IWebHostEnvironment _env;

        public SliderService(ISliderRepository sliderRepository, IWebHostEnvironment env)
        {
            _sliderRepository = sliderRepository;
            _env = env;
        }
        public void AddSlider(Slider slider)
        {
            if (slider.ImageFile == null) throw new Exception();
            slider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", slider.ImageFile);
            _sliderRepository.Add(slider);
            _sliderRepository.Commit();


        }

        public void DeleteSlider(int id)
        {
            var existSlider = _sliderRepository.Get(x => x.Id == id);
            if (existSlider == null) throw new Exception();
            Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", existSlider.ImageUrl);
            _sliderRepository.Delete(existSlider);
            _sliderRepository.Commit();
        }

        public List<Slider> GetAllSlider(Func<Slider, bool>? func = null)
        {
            return _sliderRepository.GetAll(func);
        }

        public Slider GetSlider(Func<Slider, bool> func = null)
        {
            return _sliderRepository.Get(func);
        }

        public void UpdateSlider(int id, Slider slider)
        {
            var oldslider = _sliderRepository.Get(x => x.Id == id);

            if (slider.ImageFile != null)
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\sliders", oldslider.ImageUrl);
                oldslider.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\sliders", slider.ImageFile);
            }
            oldslider.Title = slider.Title;
            oldslider.Description = slider.Description;
            oldslider.RedirectUrl = slider.RedirectUrl;
            _sliderRepository.Commit();

        }
    }
    }
