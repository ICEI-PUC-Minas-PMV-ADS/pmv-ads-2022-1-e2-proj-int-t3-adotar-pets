import {redirectIfNotLogged} from '../helpers/redirect.js';

document.addEventListener('DOMContentLoaded', async () => {
  const user = await redirectIfNotLogged('index.html');

document.addEventListener('DOMContentLoaded', function () {
  var cars = document.querySelectorAll('.carousel');
  var instances = M.Carousel.init(cars, {
    dist: 0,
    duration: 100,
    indicators: true
  })
});

document.addEventListener('DOMContentLoaded', function () {
  var elems = document.querySelectorAll('.modal');
  var instances = M.Modal.init(elems,);
});



var instance = M.Carousel.getInstance(elem);



instance.next('btn');
instance.next(1); // Mover as próximas n vezes.

instance.prev();
instance.prev(3);



var instance = M.Carousel.init({
  fullWidth: true,
  indicators: true
});
});