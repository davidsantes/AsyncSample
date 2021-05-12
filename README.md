# AsyncSample
Programación asincrónica con async y await. Pequeño ejemplo compuesto de tres casos de uso para ver las diferencias de procesamiento y tiempo entre una clase con programación síncrona y asíncrona, utilizando async y await.

El ejemplo está sacado de la [página oficial de Microsoft](https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/async/), y simula la preparación de un desayuno:

* 01. Sirva una taza de café.
* 02. Caliente una sartén y fría dos huevos.
* 03. Fría tres lonchas de beicon.
* 04. Tueste dos rebanadas de pan.
* 05. Unte el pan con mantequilla y mermelada.
* 06. Sirva un vaso de zumo de naranja.

Los puntos tratados en el ejemplo son:
* 01.Synchronous_Breakfast: servicio síncrono. Hay que esperar a que una tarea esté acabada para comenzar por la siguiente.
* 02.Asynchronous_Breakfast: servicio asíncrono no optimizado. Utiliza **async** y **await**, aunque todavía no está correctamente optimizado con la espara a la finalización de tareas.
* 03.Asynchronous_WhenAny_Breakfast: servicio asíncrono optimizado. Utiliza **WhenAny** (aunque podría haber utilizado **WhenAll**). que devuelve un objeto Task<Task> que se completa cuando finaliza cualquiera de sus argumentos. Puede esperar por la tarea devuelta, con la certeza de saber que ya ha terminado.

### Pre-requisitos 📋

Como herramientas de desarrollo necesitarás:
* Visual Studio 2019 (con la versión para .NET 5)

```
Nota: Visual Studio Code también valdría
```

### Instalación 🔧

Una vez descargado el código, existen tres proyectos de tipo Consola con las mismas operaciones (servir taza de café, calentar sartén...):
* 01.Synchronous_Breakfast: servicio síncrono.
* 02.Asynchronous_Breakfast: servicio asíncrono no optimizado.
* 03.Asynchronous_WhenAny_Breakfast: servicio asíncrono optimizado.

Compilar y verificar que no hay errores.

## Ejecutando la aplicación ⚙️

Si el código ha compilado, sólo tendrás que:
1. Si quieres, configurar  la constante **SharedConstants.DelayTime** del proyecto **Shared** el tiempo simulado que va a tardar por cada tarea. Por defecto ya tiene un valor de 3.000 milisegundos.
2. Poner como proyecto principal **01.Synchronous_Breakfast** y ejecutarlo. Ver cuánto tarda en el output.
3. Poner como proyecto principal **02.Asynchronous_Breakfast** y ejecutarlo. Ver cuánto tarda en el output.
4. Poner como proyecto principal **03.Asynchronous_WhenAny_Breakfast** y ejecutarlo. Ver cuánto tarda en el output.
5. Comparar los tres resultados. Si todo ha ido bien, verás que el último proyecto tarda mucho menos que el primero.

### ¿Qué falta? 🔩

Por ejemplo, poner el resultado en una sola pantalla, o ver cómo se tratan las excepciones, como indica la [página oficial de Microsoft](https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/async/). 

## Construido con 🛠️

* [Microsoft Visual Studio Community 2019](https://visualstudio.microsoft.com/es/vs/) - IDE  de desarrollo
* [Resharper](https://www.jetbrains.com/es-es/resharper/) - Extensión del IDE VS para optimizar el desarrollo

## Versionado 📌

Usado [Git](https://git-scm.com//) para el versionado. Por ahora, no existen diferentes versiones disponibles. Si en un futuro existieran, estarían en los diferentes tags que se crearían.

## Autores ✒️

* **David Santesteban** - *Trabajo Inicial* - [davidsantes](https://github.com/davidsantes)

## Agradecimientos 🎁

* [Luís Luzuriaga](https://github.com/B1ON1C) por recomendar el artículo]
* A cualquiera que me invite a una cerveza 🍺. 
