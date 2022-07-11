import React from 'react';
import { useState } from 'react';
import ApplicationLogo from '../components/ApplicationLogo';
import Login from '../components/Login';
import { Register } from '../components/Register/Register';

export const Authentication = () => {
  const [loginForm, setLoginForm] = useState(true);

  return (
    <div className="bg-no-repeat bg-cover bg-center relative bg__auth">
      <div className="absolute bg-gradient-to-b from-gray-900 to-black opacity-75 inset-0 z-0"></div>
      <div className="min-h-screen sm:flex sm:flex-row mx-0 justify-center items-center">
        <ApplicationLogo
          alt="netflix"
          width={280}
          height={280}
          className="cursor-pointer object-contain self-start hidden lg:flex flex-col"
        />
        {loginForm ? (
          <Login setLoginForm={setLoginForm} />
        ) : (
          <Register setLoginForm={setLoginForm} />
        )}
      </div>
    </div>
  );
};
