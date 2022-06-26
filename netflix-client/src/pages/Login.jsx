import React from 'react';
import { useState } from 'react';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import useAuth from '../hooks/useAuth';
import axios from '../utils/axios';

import ApplicationLogo from '../components/ApplicationLogo';

export const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const { login } = useAuth();
  const location = useLocation();
  const navigate = useNavigate();

  const redirect = location.state?.path || '/home';

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('/auth', { email, password });
      console.log(response);
      login(response.data.token);
      navigate(redirect, { replace: true });
    } catch (error) {
      setError(error.response.data.message);
    }
  };

  return (
    <div className="bg-no-repeat bg-cover bg-center relative bg__auth">
      <div className="absolute bg-gradient-to-b from-gray-900 to-black opacity-75 inset-0 z-0"></div>
      <div className="min-h-screen sm:flex sm:flex-row mx-0 justify-center items-center">
        <ApplicationLogo />
        <p className="p-2">{error}</p>
        <div className="flex justify-center self-center lg:w-1/2 z-10">
          <form
            onSubmit={handleLogin}
            className="p-8 backdrop-sepia-0 bg-black/60 mx-auto rounded-2xl w-100 "
          >
            <div className="mb-4 ">
              <h3 className="font-semibold text-2xl text-gray-200 flex justify-center items-center">
                Inicia con tu cuenta
              </h3>
              <p className="text-gray-500 text-sm flex justify-center items-center">
                no tienes cuenta?
                <Link
                  to="/register"
                  className="text-sm p-1 text-red-500 hover:text-red-600"
                >
                  Registrate
                </Link>
              </p>
            </div>
            <div className="space-y-5">
              <div className="space-y-2">
                <label className="text-sm font-medium text-gray-500 tracking-wide">
                  Correo electronico
                </label>
                <input
                  className=" w-full text-base px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="email"
                  name="email"
                  placeholder="mail@gmail.com"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                />
              </div>
              <div className="space-y-2">
                <label className="mb-2 text-sm font-medium text-gray-500 tracking-wide">
                  Contraseña
                </label>
                <input
                  className="w-full content-center text-base px-4 py-2 bg-slate-700 rounded-full text-gray-200"
                  type="password"
                  name="password"
                  placeholder="Ingresa tu contraseña"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </div>
              <div className="flex items-center justify-between">
                <div className="flex items-center">
                  <input
                    id="remember_me"
                    name="remember_me"
                    type="checkbox"
                    className="h-4 w-4 bg-blue-500 focus:ring-blue-400 rounded"
                  />
                  <label
                    htmlFor="remember_me"
                    className="ml-2 block text-sm text-gray-200"
                  >
                    Recordarme
                  </label>
                </div>
                <div className="text-sm">
                  <a href="#" className="text-red-500 hover:text-red-600">
                    Contraseña olvidada?
                  </a>
                </div>
              </div>
              <div>
                <button
                  type="submit"
                  className="w-full flex justify-center bg-red-500  hover:bg-red-600 text-gray-100 p-2  rounded-full tracking-wide font-semibold  shadow-lg cursor-pointer transition ease-in duration-500"
                >
                  Iniciar sesion
                </button>
                <span className="text-gray-200 flex justify-center items-center">
                  o
                </span>
                <div className="flex  space-x-2 justify-center items-end bg-gray-200 hover:bg-gray-300 text-gray-600 py-2 rounded-full transition duration-100">
                  <img
                    className=" h-5 cursor-pointer"
                    src="https://i.imgur.com/arC60SB.png"
                    alt=""
                  />
                  <button>Inicia con Google</button>
                </div>
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
