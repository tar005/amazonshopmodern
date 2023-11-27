const prod = {
    url: {
        API_URL: 'https://myapp.herokuapp.com'
    }
};

const dev = {
  url: {
    API_URL: 'https://localhost:7073'
  }   
};

export const config = process.env.NODE_ENV === 'development' ? dev : prod;