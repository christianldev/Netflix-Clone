import React from 'react';

import logo from '../../assets/img/logo_light.svg';

export default function ApplicationLogo({ width, height, className }) {
  return (
    <div className="flex-col flex  self-center p-2 sm:max-w-5xl xl:max-w-3xl z-10">
      <img
        src={logo}
        className={'mb-3' + `${className}`}
        width={width}
        height={height}
      />
    </div>
  );
}
