import React from 'react';

import logo from '../../assets/img/logo_light.png';

export default function ApplicationLogo() {
  return (
    <div className="flex-col flex  self-center p-10 sm:max-w-5xl xl:max-w-3xl z-10">
      <div className="self-start hidden lg:flex flex-col  text-white">
        <img src={logo} className="mb-3 w-84 h-48" />
      </div>
    </div>
  );
}
