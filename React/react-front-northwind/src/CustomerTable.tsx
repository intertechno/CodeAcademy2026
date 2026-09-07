import React, { useEffect, useState } from "react";

interface Customer {
  customerId: string;
  companyName: string;
  contactName: string;
  contactTitle: string;
  city: string;
  country: string;
}

const CustomersTable: React.FC = () => {
  const [customers, setCustomers] = useState<Customer[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string>("");

  useEffect(() => {
    const loadCustomers = async (): Promise<void> => {
      try {
        const response = await fetch("https://localhost:7160/api/customers");

        if (!response.ok) {
          throw new Error(`HTTP error: ${response.status}`);
        }

        const data: Customer[] = await response.json();
        setCustomers(data);
      } catch (err) {
        if (err instanceof Error) {
          setError(err.message);
        } else {
          setError("An unknown error occurred.");
        }
      } finally {
        setLoading(false);
      }
    };

    loadCustomers();
  }, []);

  if (loading) {
    return <p>Loading customers...</p>;
  }

  if (error) {
    return <p>Error: {error}</p>;
  }

  return (
    <table>
      <thead>
        <tr>
          <th>Customer ID</th>
          <th>Company Name</th>
          <th>Contact Name</th>
          <th>Contact Title</th>
          <th>City</th>
          <th>Country</th>
        </tr>
      </thead>
      <tbody>
        {customers.map((customer) => (
          <tr key={customer.customerId}>
            <td>{customer.customerId}</td>
            <td>{customer.companyName}</td>
            <td>{customer.contactName}</td>
            <td>{customer.contactTitle}</td>
            <td>{customer.city}</td>
            <td>{customer.country}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default CustomersTable;
