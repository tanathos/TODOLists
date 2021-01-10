<template>
  <div>
    {{ todo.title }}
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "nuxt-property-decorator";

@Component
export default class TodoPage extends Vue {
  todo: any = {};

  async fetch () {
    this.todo = await this.$axios.$get(`https://localhost:49155/Todos/${this.$route.params.id}`);
  }

  created () {
  }
}
</script>
