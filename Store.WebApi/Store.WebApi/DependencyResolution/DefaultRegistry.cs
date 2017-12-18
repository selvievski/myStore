// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace StructureMapWebAPIDemo.DependencyResolution
{
    using Store.Domain.Repositories;
    using Store.Services;
    using StructureMap;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            //For<IMovieRepository>().Use<MovieRepository>();
            For<ICustomerRepository>().Use<CustomerRepository>();
            For<IItemRepository>().Use<ItemRepository>();
            For<IOrderItemRepository>().Use<OrderItemRepository>();
            For<IOrderRepository>().Use<OrderRepository>();

            For<ICustomerService>().Use<CustomerService>();
            For<IItemService>().Use<ItemService>();
            For<IOrderService>().Use<OrderService>();
        }

        #endregion
    }
}