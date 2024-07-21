workspace {

    model {
        manager = person "Manager" {
            description "Manages the system and oversees operations."
        }

        orangotangoApp = softwareSystem "Orangotango App" {
            browser = container "Browser" {
                description "Angular Interface"
                technology "Angular"
                manager -> this "Manages the system"
            }

            apiGateway = container "API Gateway" {
                description "Manages and routes requests"
                technology "Ocelot"
                browser -> this "Makes requests"
            }

            packagesService = container "Packages Service" {
                description "NuGet package for shared functionalities"
                technology ".NET Core"
            }

            roomsService = container "Rooms Service" {
                description "Manages room information"
                technology ".NET Core"
                apiGateway -> this "Accesses"
                this -> packagesService "Uses"
            }

            reservationsService = container "Reservations Service" {
                description "Manages reservations"
                technology ".NET Core"
                apiGateway -> this "Accesses"
                this -> packagesService "Uses"
            }

            notificationsService = container "Notifications Service" {
                description "Notification service"
                technology ".NET Core (Background Service)"
                reservationsService -> this "Notifies about new reservations"
                roomsService -> this "Notifies about new rooms"
                this -> packagesService "Uses"
            }

            rabbitMQ = container "RabbitMQ" {
                description "Messaging system"
                technology "RabbitMQ"
                roomsService -> this "Sends/receives messages"
                reservationsService -> this "Sends/receives messages"
                notificationsService -> this "Receives messages"
            }

            roomsDatabase = container "Rooms Database" {
                description "Database for the Rooms Service"
                technology "SQL Server"
                roomsService -> this "Reads/writes"
            }

            reservationsDatabase = container "Reservations Database" {
                description "Database for the Reservations Service"
                technology "SQL Server"
                reservationsService -> this "Reads/writes"
            }
        }
    }

    views {
        systemContext orangotangoApp {
            include *
            autolayout lr
        }

        container orangotangoApp {
            include *
            autolayout lr
        }

        theme default
    }
}
