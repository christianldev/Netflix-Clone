import React from 'react';
import { Link } from 'react-router-dom';

import ApplicationLogo from '../components/ApplicationLogo';

export const Register = () => {
  return (
    <div className="bg-no-repeat bg-cover bg-center relative bg__auth">
      <div className="absolute bg-gradient-to-b from-gray-900 to-black opacity-75 inset-0 z-0"></div>
      <div className="min-h-screen sm:flex sm:flex-row mx-0 justify-center items-center">
        <ApplicationLogo />
        <div className="flex justify-center self-center lg:w-1/2 z-10">
          <form className="p-8 backdrop-sepia-0 bg-black/60 mx-auto rounded-2xl w-100 ">
            <div className="mb-4 ">
              <h3 className="font-semibold text-2xl text-gray-200 flex justify-center items-center">
                Registra una cuenta
              </h3>
              <p className="text-gray-500 text-sm flex justify-center items-center">
                ya tienes una?
                <Link
                  to="/"
                  className="text-sm p-1 text-red-500 hover:text-red-600"
                >
                  Inicia aqui
                </Link>
              </p>
            </div>
            <div className="space-y-3">
              <div className="space-y-1">
                <label className="text-sm font-medium text-gray-500 tracking-wide">
                  Nombre de usuario
                </label>
                <input
                  className=" w-full text-sm px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="text"
                  name="name"
                  placeholder="Ingresa tu nombre de usuario"
                />
              </div>
              <div className="space-y-1">
                <label className="text-sm font-medium text-gray-500 tracking-wide">
                  Correo electronico
                </label>
                <input
                  className=" w-full text-sm px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="email"
                  name="email"
                  placeholder="mail@gmail.com"
                />
              </div>
              <div className="space-y-1">
                <label className="mb-2 text-sm font-medium text-gray-500 tracking-wide">
                  Contraseña
                </label>
                <input
                  className="w-full content-center text-sm px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="password"
                  name="password"
                  placeholder="Ingresa tu contraseña"
                />
              </div>
              <div className="space-y-1">
                <label className="mb-2 text-sm font-medium text-gray-500 tracking-wide">
                  Confirmar contraseña
                </label>
                <input
                  className="w-full content-center text-sm px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="password"
                  name="confirm_password"
                  placeholder="Repite tu contraseña"
                />
              </div>
              <div className="flex items-center justify-between">
                <div className="flex items-center">
                  <input
                    id="remember_me"
                    name="remember_me"
                    type="checkbox"
                    className="w-3 h-3 text-red-600 accent-red-500 rounded border-gray-300focus:ring-2 dark:bg-gray-700 dark:border-gray-600"
                  />

                  <label
                    htmlFor="remember_me"
                    className="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300"
                  >
                    Acepto los términos y condiciones
                  </label>
                </div>
              </div>
              <div>
                <button
                  type="submit"
                  className="w-full flex justify-center bg-red-500  hover:bg-red-600 text-gray-100 p-2  rounded-full tracking-wide font-semibold  shadow-lg cursor-pointer transition ease-in duration-500"
                >
                  Registrar
                </button>
              </div>
            </div>
          </form>
        </div>
        <div className="flex w-full absolute bottom-0 backdrop-sepia-0 bg-black/60">
          <div className="flex mt-2 mb-4 flex-row justify-start items-start m-10 gap-12">
            <a className=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Preguntas
            </a>
            <a className=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Servicios
            </a>
            <a className=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Ayuda
            </a>
            <a className=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Contacto
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};
