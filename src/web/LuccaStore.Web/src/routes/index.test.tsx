import { render, screen } from '@testing-library/react';
import { MemoryRouter } from 'react-router-dom';

import RoutesPath from './';

describe('RoutesPath', () => {
    it('should render Home component for root route', () => {
        render(
            <MemoryRouter initialEntries={['/']}>
                <RoutesPath />
            </MemoryRouter>
        );
        expect(screen.getByText(/Home/i)).toBeInTheDocument();
    });

    it('should render Contact component for /contact route', () => {
        render(
            <MemoryRouter initialEntries={['/contact']}>
                <RoutesPath />
            </MemoryRouter>
        );
        expect(screen.getByText(/Contact/i)).toBeInTheDocument();
    });
});
