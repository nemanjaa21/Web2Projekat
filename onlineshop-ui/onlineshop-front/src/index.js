import "./index.css";
import App from "./App";
import { BrowserRouter } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { createRoot } from "react-dom/client";
import { AuthContextProvider } from "./contexts/auth-context";
import { GoogleOAuthProvider } from "@react-oauth/google";
import CartProvider from "./contexts/CartProvider";

createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <GoogleOAuthProvider clientId={process.env.REACT_APP_GOOGLE_ID || ""}>
      <AuthContextProvider>
        <CartProvider>
          <App />
        </CartProvider>
        <ToastContainer />
      </AuthContextProvider>
    </GoogleOAuthProvider>
  </BrowserRouter>
);
