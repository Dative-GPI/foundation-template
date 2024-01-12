<template>
    <div>
      <div class="mb-5">
        <div>
          This button opens an extension drawer.
        </div>
        <d-btn @click="openDrawer">
          {{ $tr("ui.example.open-drawer", "Open drawer") }}
        </d-btn>
      </div>
  
      <div class="mb-5">
        <div>
          Loading data from a service... Example labels will be displayed after
          being loaded.
        </div>
  
        <v-skeleton-loader v-if="loading" />
        <template v-else>
          <d-chip v-for="example in examples" :key="example.id">{{
            example.label
          }}</d-chip>
        </template>
      </div>
  
      <div class="mb-5">
        <div>
          The page's height is updated to match the extension's height.
        </div>
  
        <v-row no-gutters>
          <d-btn @click="items = []">
            {{ $tr("ui.example.reset-height", "Reset height") }}
          </d-btn>
          <d-btn @click="increaseHeight">
            {{ $tr("ui.example.increase-height", "Increase height") }}
          </d-btn>
        </v-row>
  
        <div v-for="item in items" :key="item" class="text-h1">
          {{ item }}
        </div>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { DependencyContainer } from "tsyringe";
  import { Component, Inject, Vue } from "vue-property-decorator";
  
  import {
    EXAMPLES_DRAWER_PATH,
    EXAMPLES_PATH,
    ORGANISATION,
    PROVIDER,
    SERVICES as S,
  } from "@/config";
  import { IExampleService, IExtensionCommunicationService } from "@/interfaces";
  import { ExampleDetails, ExampleInfos } from "@/domain/models";
  import { onCollectionChanged } from "@/tools";
  
  @Component({
    components: {},
  })
  export default class ExampleComponent extends Vue {
    // Properties
  
    @Inject(PROVIDER)
    container!: DependencyContainer;
  
    @Inject(ORGANISATION)
    organisationId!: string;
  
    // Data
  
    loading = false;
  
    examples: ExampleInfos[] = [];
    items: any[] = [];
  
    subscriberIds: number[] = [];
  
    // Computed Properties
  
    get exampleService() {
      return this.container.resolve<IExampleService>(S.EXAMPLESERVICE);
    }
  
    get extensionCommunicationService() {
      return this.container.resolve<IExtensionCommunicationService>(
        S.EXTENSIONCOMMUNICATIONSERVICE
      );
    }
  
    // Methods
  
    setTitle() {
      this.extensionCommunicationService.setTitle(
        this.$tr("ui.example.title", "Example page")
      );
      this.extensionCommunicationService.setCrumbs([
        {
          text: this.$tr("ui.example.title", "Example page"),
          to: `${EXAMPLES_PATH}`,
          disabled: true,
        },
      ]);
    }
  
    openDrawer() {
      this.extensionCommunicationService.openDrawer(EXAMPLES_DRAWER_PATH);
    }
  
    increaseHeight() {
      length = this.items.length;
      for (let i = length; i < length + 10; i++) {
        this.items.push(i);
      }
    }
  
    // Lifecycle
  
    mounted() {
      this.exampleService.subscribe(
        "all",
        onCollectionChanged<ExampleInfos, ExampleDetails>(() => this.examples)
      );
  
      this.fetch();
      this.setTitle();
    }
  
    async fetch() {
      this.loading = true;
      try {
        this.examples = await this.exampleService.getMany(this.organisationId);
      } finally {
        this.loading = false;
      }
    }
  }
  </script>