document.addEventListener('DOMContentLoaded', function () {
  var cars = document.querySelectorAll('.carousel');
  var instances = M.Carousel.init(cars, {
    dist: 0,
    duration: 100
  })
});

// Or with jQuery

$(document).ready(function () {
  $('.carousel').carousel();
});



var instance = M.Carousel.getInstance(elem);

/* Chamadas de Método jQuery
   Você ainda pode usar as antigas chamadas de método do plugin jQuery.
   Mas você não poderá acessar as propriedades da instância.

   $('.carousel').carousel('methodName');
   $('.carousel').carousel('methodName', paramName);
 */

instance.next('btn');
instance.next(1); // Mover as próximas n vezes.

instance.prev();
instance.prev(3);



var instance = M.Carousel.init({
  fullWidth: true,
  indicators: true
});

// Or with jQuery

$('.carousel.carousel-slider').carousel({
  fullWidth: true,
  indicators: true
});



// Paginação

const ul = document.querySelector('ul');
let allPages = 8;

function elem(allPages, page) {
  let li = ''

  let beforePages = page - 1;
  let afterPages = page = 1;
  let liActive;

  if (page > 1) {
    li += '<li class="waves-effect amber darken-0 0 btn" onclick="elem(allPages, ${page-1})" ><a>Anterior</a></li>'
  }

  for (let pageLength = beforePages; pageLength <= afterPages; pageLength++) {
    if(pageLength > allPages){
      continue;
    }

    if(pageLength ==0){
      pageLength = pageLength + 1;
    }

    if (page == pageLength) {
        liActive = 'active';
      } else {
        liActive = '';
      }

    li += '<li class="${liActive}" onclick="elem(allPages, ${pageLength})><a>${pageLength}</a></li>'
  }

  if (page < allPages) {
    li += '<li class="waves-effect btn" onclick="elem(allPages, ${page+1})><a>Próximo</a></li>'
  }

  ul.innerHTML = li;
}
elem(allPages, 2)