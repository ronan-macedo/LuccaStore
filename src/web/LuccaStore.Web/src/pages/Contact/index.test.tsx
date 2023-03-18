import React from 'react';
import { render, screen } from '@testing-library/react';
import Contact from './index';

test('renders learn react link', () => {
    render(<Contact />);
    const linkElement = screen.getByText("Contact Us!");
    expect(linkElement).toBeInTheDocument();
});
