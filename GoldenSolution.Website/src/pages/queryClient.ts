import { QueryClient } from "@tanstack/react-query";

const queryClient: QueryClient = new QueryClient({
  defaultOptions: {
    queries: {
      staleTime: Infinity,
    },
  },
});

export default queryClient;
