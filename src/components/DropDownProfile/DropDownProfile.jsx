import React from 'react';
import useAuth from '../../hooks/useAuth';
import { useNavigate } from 'react-router-dom';

export default function DropDownProfile() {
  const { logout, auth } = useAuth();
  const navigate = useNavigate();

  const onLogout = () => {
    logout();
    navigate('/');
  };

  return (
    <div
      x-show="dropdownOpen"
      className=" absolute top-20  right-4  bg-white rounded-md shadow-lg overflow-hidden z-20 w-64"
    >
      <div className="py-2">
        <a
          href="#"
          className="flex items-center px-4 py-2 hover:bg-gray-100 -mx-2"
        >
          <img
            className="h-8 w-8 rounded-full object-cover mx-1"
            src="https://images.unsplash.com/photo-1580489944761-15a19d654956?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=398&q=80"
            alt="avatar"
          />
          <p className="text-gray-600 text-sm mx-2">
            <span className="font-bold" href="#">
              Bienvenido
            </span>{' '}
            {auth.email}
          </p>
        </a>
      </div>
      <button
        onClick={onLogout}
        className="block bg-red-600 text-white text-center font-bold w-full p-2"
      >
        Cerrar sesion
      </button>
    </div>
  );
}
