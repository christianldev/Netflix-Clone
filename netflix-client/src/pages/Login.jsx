import React from 'react';

import ApplicationLogo from '../components/ApplicationLogo';

export const Login = () => {
  return (
    <div class="bg-no-repeat bg-cover bg-center relative bg__auth">
      <div class="absolute bg-gradient-to-b from-gray-800 to-gray-900 opacity-75 inset-0 z-0"></div>
      <div class="min-h-screen sm:flex sm:flex-row mx-0 justify-center items-center">
        <ApplicationLogo />
        <div class="flex justify-center self-center lg:w-1/2 z-10">
          <form class="p-8 backdrop-sepia-0 bg-black/60 mx-auto rounded-2xl w-100 ">
            <div class="mb-4 ">
              <h3 class="font-semibold text-2xl text-gray-200 flex justify-center items-center">
                Inicia con tu cuenta
              </h3>
              <p class="text-gray-500 text-sm flex justify-center items-center">
                no tienes cuenta?
                <a href="#" class="text-sm p-1 text-red-500 hover:text-red-600">
                  Registrate
                </a>
              </p>
            </div>
            <div class="space-y-5">
              <div class="space-y-2">
                <label class="text-sm font-medium text-gray-500 tracking-wide">
                  Correo electronico
                </label>
                <input
                  class=" w-full text-base px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="email"
                  name="email"
                  placeholder="mail@gmail.com"
                />
              </div>
              <div class="space-y-2">
                <label class="mb-2 text-sm font-medium text-gray-500 tracking-wide">
                  Contraseña
                </label>
                <input
                  class="w-full content-center text-base px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="password"
                  name="password"
                  placeholder="Ingresa tu contraseña"
                />
              </div>
              <div class="flex items-center justify-between">
                <div class="flex items-center">
                  <input
                    id="remember_me"
                    name="remember_me"
                    type="checkbox"
                    class="h-4 w-4 bg-blue-500 focus:ring-blue-400 rounded"
                  />
                  <label
                    for="remember_me"
                    class="ml-2 block text-sm text-gray-200"
                  >
                    Recordarme
                  </label>
                </div>
                <div class="text-sm">
                  <a href="#" class="text-red-500 hover:text-red-600">
                    Contraseña olvidada?
                  </a>
                </div>
              </div>
              <div>
                <button
                  type="submit"
                  class="w-full flex justify-center bg-red-500  hover:bg-red-600 text-gray-100 p-3  rounded-full tracking-wide font-semibold  shadow-lg cursor-pointer transition ease-in duration-500"
                >
                  Iniciar sesion
                </button>
                <span className="text-gray-200 flex justify-center items-center">
                  o
                </span>
                <div class="flex  space-x-2 justify-center items-end bg-gray-200 hover:bg-gray-300 text-gray-600 py-2 rounded-full transition duration-100">
                  <img
                    class=" h-5 cursor-pointer"
                    src="https://i.imgur.com/arC60SB.png"
                    alt=""
                  />
                  <button>Inicia con Google</button>
                </div>
              </div>
            </div>
          </form>
        </div>
        <div class="flex w-full absolute bottom-0 backdrop-sepia-0 bg-black/60">
          <div class="flex mt-2 mb-4 flex-row justify-start items-start m-10 gap-12">
            <a class=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Preguntas
            </a>
            <a class=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Servicios
            </a>
            <a class=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Ayuda
            </a>
            <a class=" md:block text-sm lg:text-base cursor-pointer text-gray-400 hover:text-white ">
              Contacto
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};
