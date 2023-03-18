import { Routes, Route } from 'react-router-dom';

import Home from '../pages/Home';
import Contact from '../pages/Contact';

const RoutesPath = () => {
    return (
        <Routes>
            <Route path='/' element={<Home />} />
            <Route path='/contact' element={<Contact />} />
        </Routes>
    );
};

export default RoutesPath;
