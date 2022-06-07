document.addEventListener('DOMContentLoaded', function() {
    var cars = document.querySelectorAll('.carousel');
    var instances = M.Carousel.init(cars,{
        dist:0
    })
  });

  // Or with jQuery

  $(document).ready(function(){
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
     