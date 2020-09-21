﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Beef.CodeGen.Config.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Beef.CodeGen.Generators
{
    /// <summary>
    /// Represents the <b>EntityDataSvc</b> code generator; where not excluded and at least one operation exists.
    /// </summary>
    public class EntityDataSvcCodeGenerator : CodeGeneratorBase<Config.Entity.CodeGenConfig, EntityConfig>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="config"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        protected override IEnumerable<EntityConfig> SelectGenConfig(Config.Entity.CodeGenConfig config)
            => Check.NotNull(config, nameof(config)).Entities.Where(x => IsFalse(x.ExcludeDataSvc) && x.Operations!.Count > 0).AsEnumerable();
    }
}