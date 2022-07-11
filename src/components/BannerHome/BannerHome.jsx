import React from 'react';

import { Swiper, SwiperSlide } from 'swiper/react';
import { Pagination, Autoplay } from 'swiper';
import 'swiper/css';
import 'swiper/css/navigation';
import BannerItemsInfo from '../BannerItemsInfo';
import { useEffect } from 'react';
import { useState } from 'react';

const BannerHome = () => {
  const [movies, setMovies] = useState([]);

  useEffect(() => {
    const getUpcomingMovies = async () => {
      const response = fetch(
        `https://api.themoviedb.org/3/movie/upcoming?api_key=${process.env.REACT_APP_MOVIE_API_KEY}&language=en-US&page=1`,
      )
        .then((res) => res.json())
        .then((data) => {
          setMovies(data.results);
        });

      return response;
    };
    getUpcomingMovies();
  }, []);

  return (
    <div className="flex justify-center items-center -mt-16">
      <Swiper
        slidesPerView={1}
        centeredSlides={true}
        autoplay={{
          delay: 2500,
          disableOnInteraction: false,
        }}
        pagination={{
          clickable: true,
        }}
        modules={[Autoplay, Pagination]}
        className="mySwiper"
      >
        {movies.map((movie) => {
          return (
            <SwiperSlide key={movie.id}>
              <BannerItemsInfo movie={movie} />
            </SwiperSlide>
          );
        })}
      </Swiper>
    </div>
  );
};

export default BannerHome;
