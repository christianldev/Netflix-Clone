import React from 'react';
import useAuth from '../hooks/useAuth';
import { useNavigate } from 'react-router-dom';

export const Dashboard = () => {
  const { logout, auth } = useAuth();
  const navigate = useNavigate();

  const onLogout = () => {
    logout();
    navigate('/');
  };

  return (
    <div>
      <h1 className="p-4 text-lg">Bienvenido: {auth.email}</h1>
      <ul className="p-4">
        <li
          className="cursor-pointer p-4 bg-red-500 w-36 rounded-2xl"
          onClick={onLogout}
        >
          Cerrar sesion
        </li>
      </ul>
    </div>
  );
};
