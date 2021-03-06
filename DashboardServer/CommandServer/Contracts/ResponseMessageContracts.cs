namespace DashboardServer.CommandServer.Contracts {
    public static class ResponseMessageContracts {
        public const string CONTAINER_CREATED = "Container successfully created";
        public const string CONTAINER_STARTED = "Container successfully started";
        public const string CONTAINER_STOPPED = "Container succesfully stopped";
        public const string CONTAINER_REMOVED = "Container succesfully removed";
        public const string CONTAINER_RESTARTED = "Container succesfully restarted";
        public const string CONTAINER_RENAMED = "Container successfully renamed";
        public const string CONTAINER_CONFIGURATION_UPDATED = "Container's ressource configuration succesfully updated";
        public const string METHOD_CALL_NOT_VIABLE = "Method call not viable. Contact maintainer for possilble implementation";
        public const string OVERVIEW_DATA_REFETCHED = "Overview data manually refetched";
        public const string STATS_DATA_REFETCHED = "Stats data manually refetched";
        public const string CONTAINER_INSPECTED = "Container successfully inspected";
    }
}
