import React from 'react';

const HeroItem = ({ movie }) => {
  const baseURL = 'https://image.tmdb.org/t/p/original/';

  return (
    <section className=" relative h-screen md:h-[90vh] lg:h-screen z-20">
      <img
        className=" object-cover"
        src={`${baseURL}${movie.backdrop_path || movie.poster_path}`}
        alt=""
      />
      <div
        className="h-full w-screen z-40 absolute top-0 left-0 bg-gradient-to-t from-black
       md:bg-gradient-to-r"
      >
        <div className=" absolute bottom-10 md:top-[20%] left-5 md:left-10 max-w-md space-y-2 md:space-y-2">
          <h1 className=" text-2xl md:text-4xl text-gray-200">{movie.title}</h1>
          <div className="flex space-x-3">
            <p className=" text-red-600">
              Release:
              <span className=" text-gray-200">{movie.release_date}</span>
            </p>
            <p className=" text-red-600">
              Rate:
              <span className=" text-gray-200">{movie.vote_average}</span>
            </p>
          </div>
          <p className=" text-gray-500 text-sm">{movie.overview}</p>
          <div className=" space-x-4 pt-6">
            <button
              className="bg-red-700 text-gray-300 h-8 w-28 md:h-10 md:w-32 rounded-full
           cursor-pointer hover:bg-red-800 hover:text-gray-100
            duration-200 transition-all ease-in-out"
            >
              Mirar ahora
            </button>
            <button
              className="bg-gray-200 text-black h-8 w-28 md:h-10 md:w-32 rounded-full
           cursor-pointer hover:bg-gray-300 hover:text-red-600 ring-red-700
            duration-200 transition-all ease-in-out  text-sm"
            >
              Agregar a lista
            </button>
          </div>
        </div>
      </div>
    </section>
  );
};

export default HeroItem;
