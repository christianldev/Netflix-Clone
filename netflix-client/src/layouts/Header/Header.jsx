import { Outlet } from 'react-router-dom';
import { useEffect, useState } from 'react';
// import BasicMenu from './BasicMenu';
import { BsSearch, BsFillBellFill } from 'react-icons/bs';
import ApplicationLogo from '../../components/ApplicationLogo';
import DropDownProfile from '../../components/DropDownProfile';

export default function Header() {
  const [isScrolled, setIsScrolled] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);

  useEffect(() => {
    const handleScroll = () => {
      if (window.scrollY > 0) {
        setIsScrolled(true);
      } else {
        setIsScrolled(false);
      }
    };

    window.addEventListener('scroll', handleScroll);

    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  return (
    <>
      <header
        className={`fixed top-0 z-50 flex w-full items-center justify-between px-4 py-2 transition-all lg:px-10  ${
          isScrolled && 'bg-[#141414]'
        }`}
      >
        <div className="flex items-center space-x-2 md:space-x-10">
          <ApplicationLogo
            alt="netflix"
            width={140}
            height={140}
            className="cursor-pointer object-contain"
          />

          <ul className="hidden md:space-x-4 md:flex text-gray-300">
            <li className="headerLink">Home</li>
            <li className="headerLink">TV Shows</li>
            <li className="headerLink">Movies</li>
            <li className="headerLink">New &amp; Popular</li>
            <li className="headerLink">My List</li>
          </ul>
        </div>

        <div className="font-light flex items-center space-x-4 text-sm text-gray-300">
          <BsSearch className="hidden sm:inline sm:w-4 sm:h-4 cursor-not-allowed" />
          <p className="hidden lg:inline cursor-not-allowed">Kids</p>
          <BsFillBellFill className="h-4 w-4 cursor-not-allowed" />
          <button onClick={() => setDropdownOpen(!dropdownOpen)}>
            <img
              src="https://rb.gy/g1pwyx"
              alt=""
              className="cursor-pointer rounded-full"
            />
          </button>
          {dropdownOpen && <DropDownProfile />}
        </div>
      </header>
      <main onClick={() => setDropdownOpen(false)}>
        <Outlet />
      </main>
    </>
  );
}
